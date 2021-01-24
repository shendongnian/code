        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(ByVal uSERINFO As USERINFO) As ActionResult
          db.Entry(uSERINFOEdit).Property(Function(x) x.Documento).IsModified = True
            db.Entry(uSERINFOEdit).Property(Function(x) x.Badgenumber).IsModified = True
            db.Entry(uSERINFOEdit).Property(Function(x) x.Name).IsModified = True
            db.Entry(uSERINFOEdit).Property(Function(x) x.Gender).IsModified = True
            db.Entry(uSERINFOEdit).Property(Function(x) x.lastname).IsModified = True
            db.Entry(uSERINFOEdit).Property(Function(x) x.email).IsModified = True
            db.Entry(uSERINFOEdit).Property(Function(x) x.DEFAULTDEPTID).IsModified = True
            db.Entry(uSERINFOEdit).Property(Function(x) x.TITLE).IsModified = True
            db.Entry(uSERINFOEdit).Property(Function(x) x.CardNo).IsModified = True
            db.Entry(uSERINFOEdit).Property(Function(x) x.FPHONE).IsModified = True
            db.Entry(uSERINFOEdit).Property(Function(x) x.HIREDDAY).IsModified = True
            db.SaveChanges()
            Return ImprimirCarnetPDF(uSERINFOEdit.USERID)
        End Function
