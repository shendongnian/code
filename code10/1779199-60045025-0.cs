c#
Excel.ApplicationClass xlapp = new Excel.ApplicationClass();
Here it is enough to say that Excel.ApplicationClass derives from Excel.Application interface and one can even instantiate Excel using Excel.Application interface. Rewriting this code as below produces exact same results:
c#
Excel.Application xlapp = new Excel.Application();
Typically, to change your code to use an interface type instead of a class type you just need to remove the 'Class' suffix and compile the code! Another way to find what the applicable interface is - look at the definition of the class type. The class usually derives from one or more interfaces. Look at the definition of each interface - one of them will have CoClass attribute and this is the interface that you are looking for.
The case with EnvDTE/VSLangProj is a little bit different. I believe there should be a recommendation coming from the VSIP team encouraging to use Type Embedding. Unfortunately, some constants in the EnvDTE/VSLangProj  assemblies cannot be embedded. For these you will need manually embed the values of the constant into your project.Since those are constant fields in the abstract classes and should never change - this is a safe thing to do.
In the IDE you can right click on the value you need to embed, then copy&paste the values locally. 
For example, suppose my C# code has code like this:
c#
System.Windows.Forms.MessageBox.Show(EnvDTE.Constants.vsDocumentKindText);
When this code is compiled I will get compilation errors:
<errors>
'EnvDTE.Constants' does not contain a definition for 'vsDocumentKindText'
Interop type 'EnvDTE.Constants' cannot be embedded. Use the applicable interface instead.
</errors>
In the IDE I will right click on vsDocumentKindText and choose "Go To Definition". This will take me what appears to be the definition of the constants class. I will copy the following lines and paste it in my code:
c#
public abstract class Constants
{
     public const string vsDocumentKindText = "{8E7B96A8-E33D-11D0-A6D5-00C04FB67F6A}";
}
Then I will make the Constants class 'internal', rename the class to EnvDTEConstants. 
c#
internal abstract class EnvDTEConstants
{
    public const string vsDocumentKindText = "{8E7B96A8-E33D-11D0-A6D5-00C04FB67F6A}";
}
Next, I will go through my code and change all the occurrences of EnvDTE.Constants to EnvDTEConstants. And now my code does compile!
c#
System.Windows.Forms.MessageBox.Show(EnvDTEConstants.vsDocumentKindText);
