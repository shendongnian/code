    public class Link : Base.Element
        {
            public Link(string XPath)
            {
                this.XPath = String.Copy(XPath);
            }
    
            /// <summary>
            /// Overriding it - just in case we need to handle clicks differently
            /// </summary>
            /// <returns></returns>
            public virtual bool Click()
            {
    
                Sync();
                Console.WriteLine(Chrome.Driver.Eval("document.evaluate('" + XPath.Replace("'", "\\\\'") + "', document.documentElement, null, XPathResult.ORDERED_NODE_SNAPSHOT_TYPE, null ).snapshotItem(0).click();"));
                return true;
            }
    
            public virtual bool WaitForExistance(int iTimeout)
            {
                return base.WaitForExistance(iTimeout);
            }
    
            public virtual bool Exists()
            {
    
                return base.Exists();
            }
    
    
            public virtual string GetText()
            {
                Sync();
                dynamic dval =  Chrome.Driver.Eval("document.evaluate('" + XPath.Replace("'", "\\\\'") + "', document.documentElement, null, XPathResult.ORDERED_NODE_SNAPSHOT_TYPE, null ).snapshotItem(0).innerText");
                return dval.result.result.value;
            }
        }
