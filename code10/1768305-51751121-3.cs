      private string getChartImage(Func<Chart> getChart, object routevals, int width, int height, string chartKey="")
        {
            string name = "Chart";
            if (routevals is SomeViewModel)
            {
                var cvm = routevals as SomeViewModel;
                chartKey = cvm.ChartKey;
                name = cvm.ChartKey;
            }
            using (var stream = new MemoryStream())
            {
                var Chart1 = getChart();
                Chart1.ImageType = ChartImageType.Png;
                Chart1.Palette = ChartColorPalette.BrightPastel;
                Chart1.SuppressExceptions = true;
                // Set chart custom palette
                Chart1.Palette = ChartColorPalette.None;
                Chart1.PaletteCustomColors = Dashboard.Support.ChartPalettes.ColorsBigList;
                Chart1.Width = width;
                Chart1.Height = height;
                Chart1.RenderType = RenderType.ImageTag;
                Chart1.BackColor = Color.White;
                Chart1.BackImageAlignment = ChartImageAlignmentStyle.BottomLeft;
                Chart1.BorderSkin.SkinStyle = BorderSkinStyle.None;
                Chart1.BorderSkin.BorderWidth = 0;
                //Chart1.BackImageTransparentColor
                Chart1.BorderColor = System.Drawing.Color.FromArgb(26, 59, 105);
                Chart1.BorderlineDashStyle = ChartDashStyle.Solid;
                Chart1.BorderWidth = 0;
                Chart1.SaveImage(stream, ChartImageFormat.Png);
                string encoded = Convert.ToBase64String(stream.ToArray());
                if (Request != null && Request.Browser != null && Request.Browser.Browser == "IE" && Request.Browser.MajorVersion <= 8)
                {
                    /*
                     * IE8 can only handle 32k of data inline so do it via the cached getChart
                     * method - i.e. store the chart in the cache and return a normal image.
                     */
                    if (encoded.Length > 32000)
                    {
                        StringBuilder result = new StringBuilder();
                        if (string.IsNullOrEmpty(chartKey))
                            chartKey = String.Format("{0}{1}", name, Guid.NewGuid());
                        System.Web.Helpers.WebCache.Set(chartKey, stream.ToArray());
                        result.Append(String.Format("<img width='{0}' height='{1}' src='{3}' alt='' usemap='#ImageMap{2}'>", width, height, name,
                            Url.Action("getChart", new { key = chartKey })));
                        return result.ToString() + Chart1.GetHtmlImageMap("ImageMap" + name); ;
                    }
                }
                /*
                 * render using data inline for speed
                 */
                string img = String.Format("<img width='{0}' height='{1}' src='data:image/png;base64,{{0}}' alt='' usemap='#ImageMap{2}'>", Chart1.Width, Chart1.Height, name);
                return String.Format(img, encoded) + Chart1.GetHtmlImageMap("ImageMap" + name);
            }
        }
