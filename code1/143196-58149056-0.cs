cs
using EventTesting;
// ARRANGE
var myObj = new MyClass();
var hook = EventHook.For(myObj)
    .HookOnly((o, h) => o.WidthChanged+= h);
// ACT
myObj.Width = 42;
// ASSERT
hook.Verify(Called.Once());
