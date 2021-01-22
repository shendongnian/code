    public class SomeHostingForm
    {
        private readonly List<Image> images; // Populate elsewhere...
        private readonly Random random = new Random();
        private void SwitchImage(ImageBox box)
        {
            box.Image = images[random.Next(images.Count)];
        }
    }
