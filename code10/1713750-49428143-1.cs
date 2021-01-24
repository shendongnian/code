     private void button1_Click(object sender, EventArgs e) {
       string[] AnalyteNames = new string[]{
         "NA", "K", "CL", "TCO2", "BUN", "CREA", "EGFR", "GLU", "CA", "ANG", "HCT", "HGB" };
       // Create checkboxes with provided titles
       // checkboxes will be unchecked by default 
       AnalyteListCheckBoxes.Items.AddRange(AnalyteNames);
     }
