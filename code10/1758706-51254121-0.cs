        /// <summary>Update the image list with random dice images.</summary>
        public static void UpdateDices()
        {
            // Iterate through the image array.
            for (var i = 0; i < imgList.Length; i++)
            {
                // Update the dice image.
                imgList[i] = GetRandomDice();
            }
        }
