    public sealed class ChromeDriverClientRequest : IDisposable
    {
        public IWebProxy proxy { set; get; }
        public string JobId { set; get; }
        public List<PageInfo> PageInfos { set; get; }
        private DirectoryInfo _packageGenerationFolderPath;
        /// <summary>
        /// Gets or sets the destination folder path.
        /// </summary>
        /// <value>The destination folder path.</value>
        public DirectoryInfo PackageGenerationFolderPath
        {
            get
            {
                if (_packageGenerationFolderPath != null && !_packageGenerationFolderPath.Exists)
                {
                    _packageGenerationFolderPath.Create();
                }
                return _packageGenerationFolderPath;
            }
            set => _packageGenerationFolderPath = value;
        }
        public ChromeDriverClientRequest()
        {
        }
        public ChromeDriverClientRequest(string jobId, List<PageInfo> pageInfos)
        {
            JobId = jobId;
            PageInfos = pageInfos;
        }
        /// <summary>
        /// DownloadWebsitePage
        /// </summary>
        /// <returns></returns>
        public void DownloadWebsitePageResources()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--window-size=1920,1080");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--disable-extensions");
            options.AddArgument("--proxy-server='direct://'");
            options.AddArgument("--proxy-bypass-list=*");
            options.AddArgument("--start-maximized");
            options.AddArgument("--headless");
            options.AddArgument("no-sandbox");
            options.AcceptInsecureCertificates = true;
            options.PageLoadStrategy = PageLoadStrategy.Normal;
            ChromeDriver driver = null;
            try
            {
                //Create a assets folder
                string path = Path.Combine(PackageGenerationFolderPath.FullName, JobId, "assets");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                driver = new ChromeDriver(options);
                
                foreach (PageInfo page in PageInfos)
                {
                    driver.Navigate().GoToUrl(page.DownloadUri);
                    object html = driver.ExecuteScript("return document.body.parentElement.outerHTML");
                    HtmlDocument htmlDoc = new HtmlDocument();
                    htmlDoc.LoadHtml(html.ToString());
                    ProcessImagesToDownload(ref htmlDoc, page);
                    ProcessHtml5ImagesTagsToDownload(ref htmlDoc, page);
                    ProcessStylesheetsToDownload(ref htmlDoc, page);
                    ProcessScriptsToDownload(ref htmlDoc, page);
                    SaveProcessedHtmlFile(ref htmlDoc, page);
                }
                createZipFile();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if(driver!=null)
                    driver.Quit();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="zipPath"></param>
        /// <param name="archiveFileName"></param>
        private void createZipFile()
        {
            string DirectoryToBeArchive = Path.Combine(PackageGenerationFolderPath.FullName, JobId);
            string DirectoryToBeArchiveZipFileName = Path.Combine(PackageGenerationFolderPath.FullName, JobId + ".zip");
            if (File.Exists(DirectoryToBeArchiveZipFileName))
            {
                File.Delete(DirectoryToBeArchiveZipFileName);
                ZipFile.CreateFromDirectory(DirectoryToBeArchive, DirectoryToBeArchiveZipFileName, CompressionLevel.Fastest, false);
            }
            else
            {
                ZipFile.CreateFromDirectory(DirectoryToBeArchive, DirectoryToBeArchiveZipFileName, CompressionLevel.Fastest, false);
            }
            Directory.Delete(DirectoryToBeArchive, true);
        }
        /// <summary>
        /// Save Processed Html File
        /// </summary>
        /// <param name="htmlDoc"></param>
        /// <param name="page"></param>
        private void SaveProcessedHtmlFile(ref HtmlDocument htmlDoc, PageInfo page)
        {
            string htmlSourceFiname = Path.GetFileName(page.DownloadUri.ToString());
            if (!string.IsNullOrEmpty(Path.GetExtension(page.DownloadUri.ToString())))
            {
                htmlSourceFiname = htmlSourceFiname.Replace(Path.GetExtension(page.DownloadUri.ToString()), ".html");
            }
            else if(!string.IsNullOrEmpty(htmlSourceFiname))
            {
                htmlSourceFiname = htmlSourceFiname + ".html";
            }
            else
            {
                htmlSourceFiname = "index.html";
            }
            using (FileStream sw = new FileStream(Path.Combine(PackageGenerationFolderPath.FullName, JobId, page.PageTcmId + "_" + htmlSourceFiname), FileMode.Create))
            {
                htmlDoc.Save(sw);
            }
        }
        /// <summary>
        /// Process Images To Download
        /// </summary>
        /// <param name="htmlDoc"></param>
        /// <param name="page"></param>
        private void ProcessImagesToDownload(ref HtmlDocument htmlDoc, PageInfo page)
        {
            HtmlNodeCollection imagesNodes = htmlDoc.DocumentNode.SelectNodes("//img");
            if (imagesNodes != null)
            {
                foreach (HtmlNode node in imagesNodes)
                {
                    if (node.Attributes["src"] != null)
                    {
                        string url = node.Attributes["src"].Value;
                        if (url.Contains("?"))
                        {
                            url = url.Substring(0, node.Attributes["src"].Value.IndexOf("?"));
                        }
                        if (url.StartsWith("//"))
                        {
                            url = string.Format("{0}:{1}", page.DownloadUri.Scheme, url);
                        }
                        if (IsAbsoluteUrl(url))
                        {
                            Uri uri = new Uri(url);
                            if (string.Compare(page.DownloadUri.Host, uri.Host, true) == 0)
                            {
                                DonwloadBinaryResource(uri);
                                node.Attributes["src"].Value = "./assets/" + Path.GetFileName(url);
                            }
                        }
                        else
                        {
                            DonwloadBinaryResource(new UriBuilder(page.DownloadUri.Scheme, page.DownloadUri.Host, page.DownloadUri.Port, url).Uri);
                            node.Attributes["src"].Value = "./assets/" + Path.GetFileName(node.Attributes["src"]!=null?node.Attributes["src"].Value.ToString():"");
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Process Html5 Images Tags To Download
        /// </summary>
        /// <param name="htmlDoc"></param>
        /// <param name="page"></param>
        private void ProcessHtml5ImagesTagsToDownload(ref HtmlDocument htmlDoc, PageInfo page)
        {
            HtmlNodeCollection imagesNodes = htmlDoc.DocumentNode.SelectNodes("//source");
            if (imagesNodes != null)
            {
                foreach (HtmlNode node in imagesNodes)
                {
                    if (node.Attributes["srcset"] != null)
                    {
                        string url = node.Attributes["srcset"].Value;
                        if (url.Contains("?"))
                        {
                            url = url.Substring(0, node.Attributes["srcset"].Value.IndexOf("?"));
                        }
                        if (url.StartsWith("//"))
                        {
                            url = string.Format("{0}:{1}", page.DownloadUri.Scheme, url);
                        }
                        if (IsAbsoluteUrl(url))
                        {
                            Uri uri = new Uri(url);
                            if (string.Compare(page.DownloadUri.Host, uri.Host, true) == 0)
                            {
                                DonwloadBinaryResource(uri);
                                node.Attributes["srcset"].Value = "./assets/" + Path.GetFileName(url);
                            }
                        }
                        else
                        {
                            DonwloadBinaryResource(new UriBuilder(page.DownloadUri.Scheme, page.DownloadUri.Host, page.DownloadUri.Port, url).Uri);
                            node.Attributes["srcset"].Value = "./assets/" + Path.GetFileName(node.Attributes["srcset"]!=null?node.Attributes["srcset"].Value.ToString():"");
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Process Stylesheets To Download
        /// </summary>
        /// <param name="htmlDoc"></param>
        /// <param name="page"></param>
        private void ProcessStylesheetsToDownload(ref HtmlDocument htmlDoc, PageInfo page)
        {
            HtmlNodeCollection linkNodes = htmlDoc.DocumentNode.SelectNodes("//link[@rel=\"stylesheet\"]");
            if (linkNodes != null)
            {
                foreach (HtmlNode node in linkNodes)
                {
                    if (node.Attributes["href"] != null)
                    {
                        string url = node.Attributes["href"].Value;
                        if (url.Contains("?"))
                        {
                            url = url.Substring(0, node.Attributes["href"].Value.IndexOf("?"));
                        }
                        if (url.StartsWith("//"))
                        {
                            url = string.Format("{0}:{1}", page.DownloadUri.Scheme, url);
                        }
                        if (!url.StartsWith("http"))
                        {
                            url = new UriBuilder(page.DownloadUri.Scheme, page.DownloadUri.Host, page.DownloadUri.Port, url).Uri.ToString();
                        }
                        if (IsAbsoluteUrl(url))
                        {
                            Uri uri = new Uri(url);
                            if (string.Compare(page.DownloadUri.Host, uri.Host, true) == 0)
                            {
                                DonwloadResource(uri);
                                node.Attributes["href"].Value = "./assets/" + Path.GetFileName(url);
                            }
                        }
                        else
                        {
                            DonwloadResource(new UriBuilder(page.DownloadUri.Scheme, page.DownloadUri.Host, page.DownloadUri.Port, url).Uri);
                            node.Attributes["href"].Value = "./assets/" + Path.GetFileName(url);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Process Scripts To Download
        /// </summary>
        /// <param name="htmlDoc"></param>
        /// <param name="page"></param>
        private void ProcessScriptsToDownload(ref HtmlDocument htmlDoc, PageInfo page)
        {
            HtmlNodeCollection scriptNodes = htmlDoc.DocumentNode.SelectNodes("//script");
            if (scriptNodes != null)
            {
                foreach (HtmlNode node in scriptNodes)
                {
                    if (node.Attributes["src"] != null)
                    {
                        string url = node.Attributes["src"].Value;
                        if (url.Contains("?"))
                        {
                            url = url.Substring(0, node.Attributes["src"].Value.IndexOf("?"));
                        }
                        if (!url.StartsWith("http"))
                        {
                            url = new UriBuilder(page.DownloadUri.Scheme, page.DownloadUri.Host, page.DownloadUri.Port, url).Uri.ToString();
                        }
                        if (IsAbsoluteUrl(url))
                        {
                            Uri uri = new Uri(url);
                            if (string.Compare(page.DownloadUri.Host, uri.Host, true) == 0)
                            {
                                DonwloadResource(uri);
                                node.Attributes["src"].Value = "./assets/" + Path.GetFileName(url);
                            }
                        }
                        else
                        {
                            DonwloadResource(new UriBuilder(page.DownloadUri.Scheme, page.DownloadUri.Host, page.DownloadUri.Port, url).Uri);
                            node.Attributes["src"].Value = "./assets/" + Path.GetFileName(url);
                        }
                    }
                }
            }
        }
        private bool IsAbsoluteUrl(string url)
        {
            return Uri.TryCreate(url, UriKind.Absolute, out Uri result);
        }
        private void DonwloadBinaryResource(Uri uri)
        {
            string resourcePathFileName = Path.Combine(PackageGenerationFolderPath.FullName, JobId, "assets", Path.GetFileName(uri.ToString()));
            if (!File.Exists(resourcePathFileName))
            {
                // Download file
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.2; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/30.0.1599.69 Safari/537.36";
                //proxy
                if (proxy != null)
                {
                    request.Proxy = proxy;
                }
                using (WebResponse response = request.GetResponse())
                {
                    using (BinaryReader reader = new BinaryReader(response.GetResponseStream()))
                    {
                        // Read file 
                        byte[] bytes = reader.ReadAllBytes();
                        // Write to local folder 
                        using (FileStream fs = new FileStream(resourcePathFileName, FileMode.Create))
                        {
                            fs.Write(bytes, 0, bytes.Length);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Donwload Resource
        /// </summary>
        /// <param name="url"></param>
        private void DonwloadResource(Uri url)
        {
            string resourcePathFileName = Path.Combine(PackageGenerationFolderPath.FullName, JobId, "assets", Path.GetFileName(url.ToString()));
            if (!File.Exists(resourcePathFileName))
            {
                using (WebClient webClient = new WebClient())
                {
                    webClient.Headers.Add("UserAgent", "Mozilla/5.0 (Windows NT 6.2; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/30.0.1599.69 Safari/537.36");
                    if (proxy != null)
                    {
                        webClient.Proxy = proxy;
                    }
                    webClient.DownloadFileAsync(url, resourcePathFileName);
                }
            }
        }
        public void Dispose()
        {
            //TODO
        }
    }
