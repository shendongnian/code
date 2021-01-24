    public static void CreateTable(IXLWorksheet ws, int beginRow, int beginColumn, List<SitesTableModel> list)
    { 
        var wsTable = ws.Cell(beginRow, beginColumn).InsertTable(list.AsEnumerable());
        // Removed range stuff I don't understand
        wsTable.Cell(beginRow, beginColumn).SetValue("Nom du site");
        wsTable.Cell(beginRow, beginColumn+1).SetValue("Adresse d'audit");
        wsTable.Cell(beginRow, beginColumn+2).SetValue("Certifications demandées");
        wsTable.Cell(beginRow, beginColumn+3).SetValue("Activités du site");
        wsTable.Cell(beginRow, beginColumn+4).SetValue("Produits du site");
    }
