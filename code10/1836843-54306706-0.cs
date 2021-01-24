using System;
namespace YourNameSpace
{
    public class Object
    {
        public static Colors Color;
    }
    public enum Colors { 
        Red,
        Blue
    }
}
In the above you would be able to set the static property `Object.Colors` as you have described:
Object.Color = Colors.Red;
