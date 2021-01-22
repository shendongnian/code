        for (int objectIndex = 0; objectIndex < theDoc.ObjectSoup.Count; objectIndex++)
            {
                try
                {
                    IndirectObject element = theDoc.ObjectSoup.ElementAt(objectIndex);
           
                    string elementType = element.GetType().ToString();
                    switch (elementType)
                    {
                        case "WebSupergoo.ABCpdf8.Objects.Annotation":
                           //process the annotation, which could be all kinds of stuff
                            WebSupergoo.ABCpdf8.Objects.Annotation annotation = (WebSupergoo.ABCpdf8.Objects.Annotation)element; 
                            
                            ProcessAnnotation(annotation);
                            
...
