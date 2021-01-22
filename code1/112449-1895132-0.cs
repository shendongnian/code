            while (objReader.ReadToFollowing("enclosure"))
            {
                objReader.MoveToFirstAttribute();
                Uri objURI = new Uri(objReader.ReadContentAsString());
                string[] objString = objURI.Segments;
                string strFileName = objString[objString.Length - 1];
                // No string constructor?! What the crap?
                DataGridViewTextBoxCell objFileCell = new DataGridViewTextBoxCell();
                objFileCell.Value = strFileName;
                DataGridViewRow objRow = new DataGridViewRow();
                objRow.Cells.Add(new DataGridViewCheckBoxCell(false));
                objRow.Cells.Add(objFileCell);
                objRow.Cells.Add(new DownloadButton(objURI, strFileName));
                this.dataGridView1.Rows.Add(objRow);
            }
