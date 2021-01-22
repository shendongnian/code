    public interface ISlice 
    {
        public Slider Slide {get;set;}
    }
    public class Slice1 : ISlice 
    {
        public Slider Slide { get; set; }
    }
    public static class SliceSlider
    {
        public static void DoSomethingCoolWithTheSliceSlide(ISlice slice) 
        {
            slice.Slide.LookitMeIAmLearningDesignPatterns();
        }
    } 
