    public class NewProjectDTO
    {
        int GCD_ID { get; set; }
        string Project_Desc { get; set; } 
        string Proponent_Name { get; set; } 
         ....... (and so on)
    } 
    public static void createNewProject(NewProjectDTO newProjectValues)
    {
     .....
    }
