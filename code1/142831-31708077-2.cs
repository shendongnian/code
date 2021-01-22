    string myXml = @"<node1 attrib1=""abc"">
                             <node1_1>
                                <node1_1_1 />
                             </node1_1>
                             <node1_2 />
                             <node1_3 />
                          </node1>
                          <node2 />
    ");
    XElement xElem = XElement.Parse(myXml);
    RemoveEmptyNodes2(xElem);
    private static void RemoveEmptyNodes2(XElement elem)
    {
        int cntElems = elem.Descendants().Count();
        int cntPrev;
        do
        {
            cntPrev = cntElems;
            elem.Descendants()
                .Where(e => 
                    string.IsNullOrEmpty(e.Value.Trim()) && 
                    !e.HasAttributes).Remove();
            cntElems = elem.Descendants().Count();
        } while (cntPrev != cntElems);
    }
