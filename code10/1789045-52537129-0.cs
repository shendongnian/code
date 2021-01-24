    public void SetYTitle(string v)
        {
            #region xml
            //	<c:valAx>
            //		<c:axId val="82091008"/>
            //		<c:scaling>
            //			<c:orientation val="minMax"/>
            //			<c:max val="90"/>
            //			<c:min val="65"/>
            //		</c:scaling>
            //		<c:delete val="0"/>
            //		<c:axPos val="l"/>
            //		<c:majorGridlines/>
            //		<c:title>
            //			<c:tx>
            //				<c:rich>
            //					<a:bodyPr rot="-5400000" vert="horz"/>
            //					<a:lstStyle/>
            //					<a:p>
            //						<a:pPr>
            //							<a:defRPr/>
            //						</a:pPr>
            //						<a:r>
            //							<a:rPr lang="de-DE"/>
            //							<a:t>title y</a:t>
            //						</a:r>
            //					</a:p>
            //				</c:rich>
            //			</c:tx>
            //			<c:layout/>
            //			<c:overlay val="0"/>
            //		</c:title>
            #endregion
            XNamespace nsC = "http://schemas.openxmlformats.org/drawingml/2006/chart";
            XNamespace nsA = "http://schemas.openxmlformats.org/drawingml/2006/main";
            var existent = ResChart.Xml.Descendants().Where(s => s.Name.LocalName.Equals("valAx")).FirstOrDefault();
            if (existent != null)
            {
                var title = new XElement(nsC + "title");
                var tx = new XElement(nsC + "tx");
                var rich = new XElement(nsC + "rich");
                var bodyPr = new XElement(nsA + "bodyPr");
                bodyPr.SetAttributeValue(XName.Get("rot"), "-5400000");
                bodyPr.SetAttributeValue(XName.Get("vert"), "horz");
                var lstStyle = new XElement(nsA + "lstStyle");
                var p = new XElement(nsA + "p");
                var pPr = new XElement(nsA + "pPr");
                var defRPr = new XElement(nsA + "defRPr");
                var r = new XElement(nsA + "r");
                var rPr = new XElement(nsA + "rPr");
                rPr.SetAttributeValue(XName.Get("lang"), "de-DE");
                var t = new XElement(nsA + "t");
                t.SetValue(v);
                var layout = new XElement(nsC + "layout");
                var overlay = new XElement(nsC + "overlay");
                overlay.SetAttributeValue(XName.Get("val"), "0");
                //build tree
                title.Add(tx);
                tx.Add(rich);
                rich.Add(bodyPr);
                rich.Add(lstStyle);
                rich.Add(p);
                p.Add(pPr);
                pPr.Add(defRPr);
                p.Add(r);
                r.Add(rPr);
                r.Add(t);
                title.Add(layout);
                title.Add(overlay);
                existent.Add(title);
            }
            else
            {
                logger.Warn("no axis def existent.");
            }
        }
