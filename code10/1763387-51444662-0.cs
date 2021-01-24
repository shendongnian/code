    using System.IO;
    using System.Linq;
    ...  
    static List<NoteColumns> ReadNoteValues(string fileName) {
      return File
        .ReadLines(fileName)
        .Where(line => !line.StartsWith('-'))
        .Select(line => line.Split('|'))
        .Select(cols => {
            var noteColumn = new NoteColumns();
    
            if (double.TryParse(cols[0], out var col))
              noteColumn.QCol = col;
          
            if (double.TryParse(cols[1], out var col))
              noteColumn.WCol = col;
    
            return noteColumn;  
         })
        .ToList();
    }
