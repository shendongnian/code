    namespace AutoEventListener
    {
        using System;
        using System.Linq;
        using System.Collections.Generic;
        using System.Reflection;
        using System.Reflection.Emit;
    
        public class EventExample
        {
            public static event EventHandler MyEvent;
    
            public void Test()
            {
                bool called;
                var eventInfo = GetType().GetEvent("MyEvent");
                EventFireNotifier.GenerateHandlerNorifier(eventInfo,
                    callbackEventInfo =>
                        {
                            called = true;
                        });
    
                MyEvent(null, null);;
            }
        }
    
        public class EventFireNotifier
        {
            static private readonly Dictionary<int, EventInfo> eventsMap = new Dictionary<int, EventInfo>();
            static private readonly Dictionary<int, Action<EventInfo>> actionsMap = new Dictionary<int, Action<EventInfo>>();
            static private int lastIndexUsed;
            public static MethodInfo GenerateHandlerNorifier(EventInfo eventInfo, Action<EventInfo> action)
            {
                MethodInfo method = eventInfo.EventHandlerType.GetMethod("Invoke");
                AppDomain myDomain = AppDomain.CurrentDomain;
                var asmName = new AssemblyName(){Name = "HandlersDynamicAssembly"};
    
                AssemblyBuilder myAsmBuilder = myDomain.DefineDynamicAssembly(
                    asmName,
                    AssemblyBuilderAccess.RunAndSave);
    
                ModuleBuilder myModule = myAsmBuilder.DefineDynamicModule("DynamicHandlersModule");
    
                TypeBuilder typeBuilder = myModule.DefineType("EventHandlersContainer", TypeAttributes.Public);
    
                var eventIndex = ++lastIndexUsed;
                eventsMap.Add(eventIndex, eventInfo);
                actionsMap.Add(eventIndex, action);
    
                var handlerName = "HandlerNotifierMethod" + eventIndex;
    
                var parameterTypes = method.GetParameters().Select(info => info.ParameterType).ToArray();
                AddMethodDynamically(typeBuilder, handlerName, parameterTypes, method.ReturnType, eventIndex);
    
                Type type = typeBuilder.CreateType();
                
                MethodInfo notifier = type.GetMethod(handlerName);
    
                var handlerDelegate = Delegate.CreateDelegate(eventInfo.EventHandlerType, notifier);
    
                eventInfo.AddEventHandler(null, handlerDelegate);
                return notifier;
            }
    
            public static void AddMethodDynamically(TypeBuilder myTypeBld, string mthdName, Type[] mthdParams, Type returnType, int eventIndex)
            {
                MethodBuilder myMthdBld = myTypeBld.DefineMethod(
                                                     mthdName,
                                                     MethodAttributes.Public |
                                                     MethodAttributes.Static,
                                                     returnType,
                                                     mthdParams);
    
                ILGenerator generator = myMthdBld.GetILGenerator();
    
                generator.Emit(OpCodes.Ldc_I4, eventIndex);
                generator.EmitCall(OpCodes.Call, typeof(EventFireNotifier).GetMethod("Notifier"), null);
                generator.Emit(OpCodes.Ret);
            }
    
            public static void Notifier(int eventIndex)
            {
                var eventInfo = eventsMap[eventIndex];
                actionsMap[eventIndex].DynamicInvoke(eventInfo);
            }
        }
    }
