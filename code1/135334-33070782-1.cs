    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Thrift.Protocol;
    using Thrift.Transport;
    
    namespace bdc
    {
        class Program
        {
            static void Main(string[] args)
            {            
                // Connection
                var socket = new TSocket("hdp1.localdomain", 9090);
                var transport =new TBufferedTransport(socket);
                var protocol = new TBinaryProtocol(transport);
                Hbase.Client hba = new Hbase.Client(protocol);
                transport.Open();            
    
                // Get table names
                Console.WriteLine("<-GET LIST OF TABLES->");      
                var tableNames = hba.getTableNames();
                foreach (var tableName in tableNames)
                Console.WriteLine(Encoding.UTF8.GetString(tableName, 0, tableName.Length));            
                
                // Insert rows       
                Console.WriteLine("<-INSERT->");      
                Mutation _mutation = new Mutation();
                _mutation.IsDelete = false;
                _mutation.Column = Encoding.UTF8.GetBytes("image:bodyimage");
                _mutation.Value = Encoding.UTF8.GetBytes("newnew image 2.jpg");
    
                hba.mutateRow(Encoding.UTF8.GetBytes("blogposts"), Encoding.UTF8.GetBytes("post1"), new List<Mutation> { _mutation }, null);
    
                // Finished
                Console.WriteLine("<-FINISHED->");  
                Console.ReadKey();                        
            }        
        }
    }
