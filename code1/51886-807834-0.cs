    public static class UpdateExtension
    {
        public static IEnumerable<Car> ChangeColorTo(
           this IEnumerable<Car> cars, Color color)
        {
           foreach (Car car in cars)
           {
              car.Color = color;
              yield return car;
           }
        }
    }
