    string url = Uri.EscapeUriString(cellValue.ToString().Replace("[", "%5B").Replace("]", "%5D"));
            if (cellValue.ToString().Length < 256)
            {
                worksheet.Cells[i + 1, j + 1].Formula = string.Format("HYPERLINK(\"{0}\",\"{1}\")", url, "Link");
            }
            else
            {
                worksheet.Cells[i + 1, j + 1].Hyperlink = new ExcelHyperLink(url) { Display = "Link" };
            }
