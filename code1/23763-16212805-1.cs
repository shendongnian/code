        public static string UrlPathCombine(string path1, string path2)
        {
            path1 = path1.TrimEnd('/') + "/";
            path2 = path2.TrimStart('/');
            return Path.Combine(path1, path2)
                .Replace(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
        }
        [TestMethod]
        public void TestUrl()
        {
            const string P1 = "http://msdn.microsoft.com/slash/library//";
            Assert.AreEqual("http://msdn.microsoft.com/slash/library/site.aspx", UrlPathCombine(P1, "//site.aspx"));
            var path = UrlPathCombine("Http://MyUrl.com/", "Images/Image.jpg");
            Assert.AreEqual(
                "Http://MyUrl.com/Images/Image.jpg",
                path);
        }
