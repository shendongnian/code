public class BugFixAttribute : System.Attribute
{
 ...
 public String toString(){
   return string.Format("\nBugId: {0}\nProgrammer: {1}", this.BugId, this.Programmer));
 }
}
