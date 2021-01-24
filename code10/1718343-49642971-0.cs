                int tl = items.ShelfId;
                var ttl = await _context.Shelfs.FirstOrDefaultAsync(b => b.ShelfId == tl);
                var l = ttl.Name;
                int tnn = items.CategoryId;
                var ttnn = await _context.Categories.FirstOrDefaultAsync(b => b.CategoryId == tnn);
                var nn = ttnn.Subject;
                string a = items.AuthorLastName.Substring(0, 1);
                var lnna = l + nn + a;
                var ichars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".ToCharArray();
                var currenti = _context.Items.Count(i => i.LibraryItemNumber.Contains(lnna));
                if (currenti > 0 && currenti < 62)
                {
                    var i = ichars[currenti];
                    var LNNAI = lnna + i;
                    items.LibraryItemNumber = LNNAI;
                }
                else if (currenti == 0)
                {
                    var i = ichars[0];
                    var LNNAI = lnna + i;
                    items.LibraryItemNumber = LNNAI;
                }
                else
                {
                    items.LibraryItemNumber = "Exceed";
                }
