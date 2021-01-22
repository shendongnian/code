    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;
    namespace ClassLibrary1
    {
        [ComVisible(true)]
        [Guid("1CEB24F2-BF13-417F-B5BC-DB8E82A56EAE")]
        public interface ITestEntity1 //This is how TestEntity1 is visible to the COM code...so it needs a Guid.
        {
            bool Thing { get; set; }
        }
    
    
        [ComVisible(true)]
        [Guid("C8B5A7C2-F67C-4271-A762-3642754F2233")]
        public class TestEntity1 : ITestEntity1  //Created by the COM runtime...needs a Guid.
        {
            public bool Thing { get; set; }
        }
    
        [ComVisible(true)]
        [Guid("8904A7EC-D865-4533-91EC-1F68524651D0")]
        public interface ITestEntity2
        {
            string Description { get; set; }
        }
    
        [ComVisible(true)]
        [Guid("668EE2E8-5A60-468B-8689-D9327090AA44")]
        public class TestEntity2 : ITestEntity2
        {
            public string Description { get; set; }
        }
    
        [ComVisible(true)]
        [Guid("2791082F-F505-49C4-8952-80C174E4FE96")]
        public interface ITestGateway
        {
            //MarshalAsAttribute is somewhat important, it tells the tlbexp.exe tool to mark
            // the comInputValue parameter as IUnknown* in the COM interface.
            //This is good because VARIANTS kinda suck...You'll see what I mean in the C++
            // side.  It also keeps some jack-wagon from passing a VARIANT_BOOL in
            // on your object parameter.
            void DoSomething(string a, [MarshalAs(UnmanagedType.Interface)]object comInputValue);
        }
    
        [ComVisible(true)]
        [Guid("C3D079F3-7869-4B3E-A742-263775C6EA63")]
        public class TestGateway : ITestGateway
        {
            public void DoSomething(string a, object comInputValue)
            {
                if (a == "yes")
                {
                    var entity = (TestEntity1)comInputValue;
                }
                else
                {
                    var entity = (TestEntity2) comInputValue;
                }
                //OR
    
                if(comInputValue is TestEntity1)
                {
                    //Do whatever here, and you don't need to test
                    // a string input value.
                }
                else if(comInputValue is TestEntity2)
                {
                    //Other stuff is done here.
                }
                else
                {
                    //Error condition??
                }
            }
        }
    }
