    public class DoWork(){
    
      var scheduleEntries = new List<ScheduleEntry>();
            File.ReadAllLines(Server.MapPath("App_Data/Classes.txt")).Select(i=>scheduleEntries.Add(new ScheduleEntry(i)));
      var maxRowCount = scheduleEntries.Max(i=>i.Ordinal);
      for (int k = 1; k <= maxRowCount; k++){
        var tableRow = new TableRow;
        // Monday
         var mondayCellItem = scheduleEntries.FirstOrDefault(i=>i.Ordinal == k && i.Day == "Monday")
        var mondayCell = new TableCell{
          Text = $"{mondayCellItem.Class}"
        // Tuesday, etc
        tableRow.Cells.Add(mondayCell);
        tableRow.Cells.Add(tuesdayCell);
        //etc
        }
        
      }
    
      internal class ScheduleEntry(){
        public string Day {get;set;}
        public int Ordinal {get;set;}
        public string ClassName {get;set;}
    
        public ScheduleEntry(string inRow){
          var values = inRow.Split(',');
          Day = values[1]; // should do some validation here
          Ordinal = int.Parse(values[2]); // and here
          ClassName = values[3]; // and here
      }
    }
    }
