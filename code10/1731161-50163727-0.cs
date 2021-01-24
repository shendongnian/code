     var obj = (from emisor in _context.DbSetEmisores
                           where emisor.EmisorCuenta == cuenta
                           select new EmisorDto
                           {
                               Segmento =
                               ((from itemConf in _context.ItemsDeConfiguracion
                                 where itemConf.ConfigID == "SEGM" && itemConf.ConfigItemID == emisor.SegmentoId
                                 select new { itemConf.ConfigItemDescripcion }).FirstOrDefault().ConfigItemDescripcion),
                               Marca =
                               ((from itemConf in _context.ItemsDeConfiguracion
                                 where itemConf.ConfigID == "MRCA" && itemConf.ConfigItemID == emisor.MarcaId
                                 select new { itemConf.ConfigItemDescripcion }).FirstOrDefault().ConfigItemDescripcion),
                               Producto = emisor.Producto,
                               Familia = emisor.Familia,
                               SegmentoId = emisor.SegmentoId,
                               MarcaId = emisor.MarcaId,
                           }).FirstOrDefault();
