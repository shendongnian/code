    public class Student {
    // TAG MEMBER WITH CUSTOM ATTRIBUTE
    [GradeAttribute()]
    public int Grade
    {
        get;
        set;
    }
    public string TheNameOfTheGradeProperty
    {
        get
        {
            /* Use Reflection.
               Loop over properties of this class and return the
               name of the one that is tagged with the 
               custom attribute of type GradeAttribute.
            */
        }
    }
    // More properties..    
    } 
