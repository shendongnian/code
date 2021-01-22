        abstract class Animal
        {
            public abstract void Move();
        }
        public class Cat : Animal
        {
            public override void Move()
            {
                //Cat specific behavior
            }
        }
        public class Bird : Animal
        {
            public override void Move()
            {
                //Bird specific behavior
            }
        }
