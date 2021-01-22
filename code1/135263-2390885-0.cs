        Regex regex = new Regex(@"([\?\&])id=[^\?\&]+[\?\&]?");
        [TestMethod]
        public void RegexReplacesParameterInMiddle()
        {
            string url = "somepage.aspx?cat=22&id=SomeId&param2=4";
            url = regex.Replace(url, "$1");
            Assert.AreEqual("somepage.aspx?cat=22&param2=4",url);
        }
        [TestMethod]
        public void RegexReplacesParameterInFront()
        {
            string url = "somepage.aspx?id=SomeId&cat=22&param2=4";
            url = regex.Replace(url, "$1");
            Assert.AreEqual("somepage.aspx?cat=22&param2=4", url);
        }
        
        [TestMethod]
        public void RegexReplacesParameterAtEnd()
        {
            string url = "somepage.aspx?cat=22&param2=4&id=SomeId";
            url = regex.Replace(url, "$1");
            Assert.AreEqual("somepage.aspx?cat=22&param2=4&", url);
        }
        
        [TestMethod]
        public void RegexReplacesSoleParameter()
        {
            string url = "somepage.aspx?id=SomeId";
            url = regex.Replace(url, "$1");
            Assert.AreEqual("somepage.aspx?", url);
        }
        public void RegexIgnoresMissingParameter()
        {
            string url = "somepage.aspx?foo=bar&blet=monkey";
            url = regex.Replace(url, "$1");
            Assert.AreEqual("somepage.aspx?foo=bar&blet=monkey", url);
        }
