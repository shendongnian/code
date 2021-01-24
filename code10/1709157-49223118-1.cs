    using System;
    using System.Collections.Generic;
    
    class Programs
    {
        static void Main(string[] args)
        {
            Screen screenDepartures = ScreenFactory.CreateScreen("Departure");
            Screen screenArrivals = ScreenFactory.CreateScreen("Arrival");
    
            //Whatever you are doing with the screens here..
    
    
            Console.ReadLine();
        }
    
        public static class ScreenFactory
        {
            public static Screen CreateScreen(string screenData)
            {
                Screen screen = new Screen {GridConfiguration = GetGridConfiguration()};
    
                switch (screenData)
                {
                    case "Arrival":
                    {
                        screen.GridData = new ArrivalDTO().GridData();
                        break;
                    }
                    case "Departure":
                    {
                        screen.GridData = new DepartureDTO().GridData();
                        break;
                    }
                    default: return null;
                }
    
                return screen;
            }
    
            private static List<GridConfiguration> GetGridConfiguration()
            {
                List<GridConfiguration> gridConfiguration = new List<GridConfiguration>();
                return gridConfiguration;
            }
        }
    }
    
    internal class Screen
    {
        public IEnumerable<GridConfiguration> GridConfiguration { get; set; }
        public IEnumerable<IGridType> GridData { get; set; }
    
    }
    
    public interface IGridType
    {
        IEnumerable<IGridType> GridData();
    }
    
    
    public abstract class BaseDTO : IGridType
    {
        public int ID { get; set; }
        public string FlightNumber { get; set; }
        
        public DateTime SchduledTime { get; set; }
    
        public virtual IEnumerable<IGridType> GridData()
        {
            throw new NotImplementedException();
        }
    }
    
    public class ArrivalDTO : BaseDTO
    {
        public DateTime ArrivalTime { get; set; }
        public override IEnumerable<IGridType> GridData()
        {
            return new ArrivalService().GetArrivalData();
        }
    }
    
    public class DepartureDTO : BaseDTO
    {   public DateTime DepartureTime { get; set; }
        public override IEnumerable<IGridType> GridData()
        {
            return new DepartureService().GetDepartureData();
        }
    }
    
    public class GridConfiguration
    {
        public int Id { get; set; }
        public string ColumnName { get; set; }
        public int Index { get; set; }
        public int FilterText { get; set; }
    }
    
    public class DepartureService
    {
        public IEnumerable<DepartureDTO> GetDepartureData()
        {
            List<DepartureDTO> list = new List<DepartureDTO>();
            list.Add(new DepartureDTO { ID = 1, DepartureTime = DateTime.Now, FlightNumber = "test" });
            list.Add(new DepartureDTO { ID = 2, DepartureTime = DateTime.Now, FlightNumber = "test2" });
            return list;
        }
    }
    
    class ArrivalService
    {
        public IEnumerable<ArrivalDTO> GetArrivalData()
        {
            List<ArrivalDTO> list = new List<ArrivalDTO>();
            list.Add(new ArrivalDTO { ID = 1, ArrivalTime = DateTime.Now, FlightNumber = "test" });
            list.Add(new ArrivalDTO { ID = 2, ArrivalTime = DateTime.Now, FlightNumber = "test2" });
            return list;
        }
    }
 
