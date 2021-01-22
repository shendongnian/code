     private void SortIdNodes(XElement parent, String elementName, String sortElementname)
         {
             XNode prevElem = null;
             XNode nextElem = null;
             // Initial node count, to verify sets are equal
             int initialElementsCount = parent.Descendants().Count();
             List<XElement> unOrdered = parent.Descendants(elementName).ToList<XElement>();
             if (unOrdered.Count() < 2){
                 return; // No sorting needed
             }
             // Make note of the neighbors
             prevElem = unOrdered[0].PreviousNode;
             nextElem = unOrdered.Last().NextNode;
             // Remove set from parent
             unOrdered.ForEach(el =>
             {
                 el.Remove();
             });
             // Order the set, language (IEnumerable) semantics prevents us from changing order in place
             List <XElement> ordered =  unOrdered.OrderBy(x => x.Descendants(sortElementname).FirstOrDefault().Value).ToList<XElement>();
             // Add to parent in correct order
             if (prevElem != null)  // If there's a first neighbor
             {
                 ordered.ForEach(el =>
                 {
                     prevElem.AddAfterSelf(el);
                     prevElem = el;
                 });
             }
             else if (nextElem != null)  // If there's only an end neighbor
             {
                 ordered.Reverse();
                 ordered.ForEach(el =>
                 {
                     nextElem.AddBeforeSelf(el);
                     nextElem = el;
                 });
             }
             else // we're the only children of the parent, just add
             {
                 ordered.ForEach(el =>
                 {
                     parent.Add(el); // add in order
                 });
             }
             int finalElementCount = parent.Descendants().Count();
             if (initialElementsCount != finalElementCount)
             {
                 throw new Exception("Error with element sorting, output collection not the same size as the input set.");
             }
         }
