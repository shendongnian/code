    0:000> !dumpheap -type Generic.List  
     Address       MT     Size
    01eb29a4 662ed948       24     
    total 1 objects
    Statistics:
          MT    Count    TotalSize Class Name
    662ed948        1           24 System.Collections.Generic.List`1[[System.Double,  mscorlib]]
    Total 1 objects
    0:000> !objsize 01eb29a4 
    sizeof(01eb29a4) =      8000036 (    0x7a1224) bytes     (System.Collections.Generic.List`1[[System.Double, mscorlib]])
    0:000> !do 01eb29a4 
    Name: System.Collections.Generic.List`1[[System.Double, mscorlib]]
    MethodTable: 662ed948
    EEClass: 65ad84f8
    Size: 24(0x18) bytes
     (C:\Windows\assembly\GAC_32\mscorlib\2.0.0.0__b77a5c561934e089\mscorlib.dll)
    Fields:
          MT    Field   Offset                 Type VT     Attr    Value Name
    65cd1d28  40009d8        4      System.Double[]  0 instance 02eb3250 _items
    65ccaaf0  40009d9        c         System.Int32  1 instance  1000000 _size
    65ccaaf0  40009da       10         System.Int32  1 instance  1000000 _version
    65cc84c0  40009db        8        System.Object  0 instance 00000000 _syncRoot
    65cd1d28  40009dc        0      System.Double[]  0   shared   static _emptyArray
        >> Domain:Value dynamic statics NYI
     00505438:NotInit  <<
    0:000> !objsize 02eb3250 
    sizeof(02eb3250) =      8000012 (    0x7a120c) bytes (System.Double[])
 
