    var doc = wb.Browser.Document
    var elem = doc.GetElementById(elementId);
    object obj = elem.DomElement;
    System.Reflection.MethodInfo mi = obj.GetType().GetMethod("click");
    mi.Invoke(obj, new object[0]);
