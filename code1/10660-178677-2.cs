    .class public interface abstract auto ansi MyInterface
{
    .property instance valuetype TestInterfaces.MyInterface/MyEnum Number
    {
        .get instance valuetype TestInterfaces.MyInterface/MyEnum TestInterfaces.MyInterface::get_Number()
    }
    .class auto ansi sealed nested public MyEnum
        extends [mscorlib]System.Enum
