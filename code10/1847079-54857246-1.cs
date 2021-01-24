// Put all your shared methods in generic classes in here.
public static class MyMethods
{
    public static T Method<T>(this T x) where T : MyClass
    {
        ...
    }
}
Your classes don't change much, except they won't need to mention `Method` (or the other shared methods) at all.
public abstract class MyClass
{
    ...
}
public class MyClass1 : MyClass
{
    ...
}
public class MyClass2 : MyClass
{
    ...
}
