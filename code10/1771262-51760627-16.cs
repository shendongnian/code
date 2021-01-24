    //UnityEventBase has this field that it serializes
           PersistentCallGroup m_PersistentCalls;// holds a list of all the methods to call when the event is invoked
     
    //and PersistentCallgroup has this
           List<PersistentCall> m_Calls;
     
    //each PersistentCall has these fields
           UnityEventCallState m_CallState // an enum for off, editor and runtime, or runtime only
           PersistentListenerMode m_Mode // enum determining which internal delegate to call and which inputs to draw in inspector
           UnityEngine.Object m_Target // the instance which to call the method on
           string m_TypeName // the concrete type name of the target (needed for polymorphism)
           string m_MethodName // the name of the method to call in target
         
           ArgumentCache m_Arguments //container class which holds the arguments that are passed into the calling function, used for static calls
     
    //ArgumentCache has the following variables
           UnityEngine.Object m_ObjectArgument
           string m_ObjectArgumentAssemblyTypeName // used to confirm if objectArgument is valid
           int m_IntArgument
           float m_FloatArgument
           string m_StringArgument
           bool m_BoolArgument
 
