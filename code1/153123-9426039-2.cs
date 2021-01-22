        HtmlDocument hDoc;
        HtmlNodeCollection nodeCollection;
        public void InitInstance(string htmlCode) {
            hDoc.LoadHtml(htmlCode);
            nodeCollection = new HtmlNodeCollection();
        }
        private void GetAllNodesInnerTextByTagName(HtmlNode node, string tagName) {
            if (null == node.ChildNodes) {
                return ;
            } else {
                HtmlNodeCollection nCollection = node.SelectNodes( tagName );
				if( null != nCollection ) {
					for( int i=0; i<nCollection.Count; i++) {
						nodeCollection.Add( nCollection[i]);
						nCollection[i].Remove();
					}
				}
				nCollection=node.ChildNodes;
				if(null != nCollection) {
					for(int i=0;i<nCollection.Count; i++) {
						GetAllNodesInnerTextByTagName( nCollection[i] , tagName );
					}
				}
            }
