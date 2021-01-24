            XLWorkbook workbook;
            workbook = null;
            try
            {
                var filename = yourpath.xml
                workbook = new XLWorkbook(filenamee);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return;
            }
            bool sucesso = workbook.Worksheets.TryGetWorksheet("Célula", out IXLWorksheet ws);
            if (!sucesso)
            {
                MessageBox.Show("Not possible to Open the file.");
                return;
            }
            foreach (var row in ws.RowsUsed()) //rowsused()
            {
                UA ua = new UA { };
                ua.DistritoCod = row.Cell(1).GetString();
                ua.Distrito = row.Cell(2).GetString();
                ua.ConcelhoCod = row.Cell(3).GetString();
                ua.Concelho = row.Cell(4).GetString();
                ua.IDEndereço = row.Cell(5).GetString();
                ua.TipoDeRua = row.Cell(6).GetString();
                ua.Endereço = row.Cell(7).GetString();
                ua.IDLocalidade = row.Cell(8).GetString();
                ua.Localidade = row.Cell(9).GetString();
                ua.CP4 = row.Cell(10).GetString();
                ua.CP3 = row.Cell(11).GetString();
                ua.NumPolicia = row.Cell(12).GetString();
                ua.Andar = row.Cell(13).GetString();
                ua.Fracçao = row.Cell(14).GetString();
                ua.Edificio_cad = row.Cell(17).GetString();
                ua.Celula = row.Cell(18).GetString();
                ua.Latitude = row.Cell(21).GetString().Replace(",", ".");
                ua.Longitude = row.Cell(22).GetString().Replace(",", ".");
                ua.Tpo_HP = row.Cell(24).GetString();
                ua.NomeEmpresa = row.Cell(25).GetString();
                ua.ValidaçaoMoradas = row.Cell(28).GetString();
                ua.Comentario = row.Cell(29).GetString();
                listagem.Add(ua);
                if (edificios.FindAll(x => x.id == ua.Edificio_cad).Count == 0)
                {
                    edificios.Add(item: new { id = ua.Edificio_cad, lat = ua.Latitude, lon = ua.Longitude });
                }
            }
            dataGridView1.DataSource = listagem;
