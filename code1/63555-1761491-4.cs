    using System;
    using System.Reflection;
    using System.Security;
    using System.Security.Permissions;
    using System.Security.Policy;
    namespace PartialTrustTest
    {
        internal class Program : MarshalByRefObject
        {
            public void PartialTrustSuccess()
            {
                Console.WriteLine("partial trust success #1");
            }
            public void PartialTrustFailure()
            {
                FieldInfo fi = typeof(Int32).GetField("m_value", BindingFlags.Instance | BindingFlags.NonPublic);
                object value = fi.GetValue(1);
                Console.WriteLine("value: {0}", value);
            }
            private static AppDomain CreatePartialTrustDomain()
            {
                AppDomainSetup setup = new AppDomainSetup() { ApplicationBase = AppDomain.CurrentDomain.BaseDirectory };
                PermissionSet permissions = new PermissionSet(null);
                permissions.AddPermission(new SecurityPermission(SecurityPermissionFlag.Execution));
                permissions.AddPermission(new ReflectionPermission(ReflectionPermissionFlag.RestrictedMemberAccess));
                return AppDomain.CreateDomain("Partial Trust AppDomain", null, setup, permissions);
            }
            static void Main(string[] args)
            {
                AppDomain appDomain = CreatePartialTrustDomain();
                Program program = (Program)appDomain.CreateInstanceAndUnwrap(
                    typeof(Program).Assembly.FullName,
                    typeof(Program).FullName);
                program.PartialTrustSuccess();
                try
                {
                    program.PartialTrustFailure();
                    Console.Error.WriteLine("!!! partial trust test failed");
                }
                catch (FieldAccessException)
                {
                    Console.WriteLine("partial trust success #2");
                }
            }
        }
    }
 C:\temp\PartialTrustTest\bin\Debug>PartialTrustTest.exe
 partial trust success #1
 partial trust success #2
