    using System;
    using System.Collections.Generic;
    
    namespace Flags
    {
        [Flags]
        enum SourceEnum
        {
            SNone = 0x00,
    
            SA = 0x01,
            SB = 0x02,
            SC = 0x04,
            SD = 0x08,
    
            SAB = SA | SB,
    
            SALL = -1,
        }
    
        [Flags]
        enum DestEnum
        {
            DNone = 0x00,
    
            DA = 0x01,
            DB = 0x02,
            DC = 0x04,
    
            DALL = 0xFF,
        }
    
        class FlagMapper
        {
            protected Dictionary<int, int> mForwardMapping;
    
            protected FlagMapper(Dictionary<int, int> mappings)
            {
                this.mForwardMapping = mappings;
            }
    
            protected int Map(int a)
            {
                int result = 0;
    
                foreach (KeyValuePair<int, int> mapping in this.mForwardMapping)
                {
                    if ((a & mapping.Key) != 0)
                    {
                        if (mapping.Value < 0)
                        {
                            throw new Exception("Cannot map");
                        }
    
                        result |= mapping.Value;
                    }
                }
    
                return result;
            }
        }
    
        class SourceDestMapper : FlagMapper
        {
            public SourceDestMapper()
                : base(new Dictionary<int, int>
                {
                    { (int)SourceEnum.SA, (int)DestEnum.DA },
                    { (int)SourceEnum.SB, (int)DestEnum.DB },
                    { (int)SourceEnum.SC, (int)DestEnum.DC },
                    { (int)SourceEnum.SD, -1 }
                })
            {
            }
    
            public DestEnum Map(SourceEnum source)
            {
                return (DestEnum)this.Map((int)source);
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                SourceDestMapper mapper = new SourceDestMapper();
    
                Console.WriteLine(mapper.Map(SourceEnum.SA));
                Console.WriteLine(mapper.Map(SourceEnum.SA | SourceEnum.SB));
                Console.WriteLine(mapper.Map(SourceEnum.SAB));
                
                //Console.WriteLine(mapper.Map(SourceEnum.SALL));
    
                Console.WriteLine(mapper.Map(SourceEnum.SD));
            }
        }
    }
