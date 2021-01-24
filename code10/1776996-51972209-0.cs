    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace ConsoleApp4 {
        class Program {
            static void Main(string[] args) {
                string inputString = "time, M1.A, M1.B, M1.C, M2.A, M2.B, M2.C, M3.A, M3.B, M3.C";
                string[] attrList = inputString.Split(',');
                // 1. Get all machines with attributes
                List<MachineAttribute> MachineAttributeList = new List<MachineAttribute>();
                for (int i = 1; i < attrList.Length; i++) {
                    MachineAttributeList.Add(new MachineAttribute(attrList[i]));
                }
            
                // 2. For each machine create 
                foreach (var machine in MachineAttributeList.Select(x=>x.Machine).Distinct()) {
                    Console.Write(attrList[0]);
                    foreach (var attribute in MachineAttributeList.Where(x=>x.Machine == machine)) {
                        Console.Write(attribute + ",");
                    }
                    Console.WriteLine();
                }
                Console.ReadLine();
            }
        }
        public class MachineAttribute {
            public string Machine { get; }
            public string Attribute { get; }
            public MachineAttribute(string inputData) {
                var array = inputData.Split('.');
                if (array.Length > 0) Machine = array[0];
                if (array.Length > 1) Attribute = array[1];
            }
            public override string ToString() {
                return Machine + "." + Attribute;
            }
        }
    }
