    var castListMethod = typeof(Ext).GetMethod("CastList").MakeGenericMethod(_messageItemMap[level1Code]);
    var theMessageItemModel = castListMethod.Invoke(null, new object[] { messages });
    
    var printMethod = printHelper.GetType().GetMethod("Print").MakeGenericMethod(theMessageItemModel.GetType().GetGenericArguments().Single());
    var docRender = printMethod.Invoke(printHelper, new [] { theMessageItemModel }) as IDocumentRender;
    file = docRender.Save(exportFormat);
