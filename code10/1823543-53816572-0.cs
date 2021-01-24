       class TuppleExample
    {
        public (Apple, Orange) GetAppleAndOrage()
        {
            var apple = new Apple();
            var orange = new Orange();
            return (apple, orange);
        }
        public void EatAppleAndOrange()
        {
            var (apple, orange) = this.GetAppleAndOrage();
            apple.Bite();
            orange.PeelThenBite();
        }
    }
    class Apple { }
    class Orange { }
