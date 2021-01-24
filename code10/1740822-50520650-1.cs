    interface ILandAnimal
    {
        void ToWalk();
        void ToBreed();
    }
    interface IWaterAnimal
    {
        void ToSwim();
        void ToBreed();
    }
    public class Amphibians : ILandAnimal, IWaterAnimal
    {
        //only one implementation of ToBreed ()
        //  (which is there in both interface)
        public void ToBreed() { }
        public void ToWalk() { }
        public void ToSwim() { }
    }
