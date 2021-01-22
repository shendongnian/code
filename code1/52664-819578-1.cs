    var qry = from b in dc.Blobs
              orderby b.RowVersion descending
              select new {b.Id, b.Size, b.Signature, b.RowVersion};
    var typedQry = from b in qry.AsEnumerable()
                   select new BlobDetails {
                      Id = b.Id, Size = b.Size,
                      Signature = b.Signature, RowVersion = b.RowVersion};
    return typedQry.ToList();
