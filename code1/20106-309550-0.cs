public partial class Form1:Form
{
MyClass[] MyArrayObject; // declare it here and it will be available everywhere
public Form1()
{
 //instantiate it here
 MyArrayObject = new MyClass[50];
 for (int i = 0; i < 50; i++)
 {
    MyArrayObject[i] = new MyClass();
 }
}
