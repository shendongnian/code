    from D in ctx.Documents
    join DC in ctx.DocClasses on D.DocClass equals DC.ID
    join DSC in ctx.DocSubClasses on new { D.DocSubClass, DC.ID } equals new { DocSubClass = DSC.ID, ID = DSC.DocClassID }
    join F in ctx.DocPathFolders on D.DocPathFolderID equals F.ID
    where DC.ShortName == "PAY" && DSC.Name == "xxxx" && (F.Description).ToUpper() == "READY TO SEND"
    select D.ID;
