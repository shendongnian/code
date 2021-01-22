    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace App
    {
        public static class ListExtension
        {
            public static int RemoveAll<T>(this List<T> list, Predicate<T> match, uint maxcount)
            {
                uint removed = 0;
                Predicate<T> wrappingmatcher = (item) =>
                {
                    if (match(item) && removed < maxcount)
                    {
                        removed++;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                };
                return list.RemoveAll(wrappingmatcher);
            }
        }
        public interface IHero { }
        public class Batman : IHero { }
        public class HeroCompilation
        {
            public List<IHero> Herolist;
            public HeroCompilation()
            {
                Herolist = new List<IHero>();
            }
            public void AddBatmans(int count){
                for (int i = 1; i <= count; i++) Herolist.Add(new Batman());
            }
        }
        class Program
        {
            static void ConsoleWriteBatmanCount(List<IHero> hero)
            {
                Console.WriteLine("There are {0} Batmans", hero.Count);
            }
            static void Main(string[] args)
            {
                HeroCompilation tester = new HeroCompilation();
                ConsoleWriteBatmanCount(tester.Herolist);
                tester.AddBatmans(10);
                ConsoleWriteBatmanCount(tester.Herolist);
                tester.Herolist.RemoveAll((x) => { return true; }, 4);
                ConsoleWriteBatmanCount(tester.Herolist);
                tester.Herolist.RemoveAll((x) => { return true; }, 4);
                ConsoleWriteBatmanCount(tester.Herolist);
                tester.Herolist.RemoveAll((x) => { return true; }, 4);
                ConsoleWriteBatmanCount(tester.Herolist);
                while (true) ;
            }
        }
    }
