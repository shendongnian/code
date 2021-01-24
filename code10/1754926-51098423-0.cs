     int left = 232;
     int top = 100;
     int step_x = 80;
     int step_y = 20;
     // outer loop - lines
     while (reader.Read()) {
       var split = Convert.ToString(reader["subjects"])
         .Split(new string[] { ",", " " }, StringSplitOptions.RemoveEmptyEntries); 
       // inner loop - columns
       for (int j = 0; j < split.Length; j++) {
         new Label() {
           Name = $"label{i}",
           Text = split[j],
           // Notice "top + step_y * i" - label after label
           Location = new Point(left, top + step_y * i), 
           Parent = this, // equal to this.Controls.Add(l); 
         };
       }
       left += step_x;
     }
