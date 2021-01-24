     // Delete all slides except Slide at Index i
                        int countSlide = CountSlides(filePath + i + ".pptx");  // Count number of slides
                        int newIndex = i; // Slide index that you want to keep it
                        while (1 < countSlide )
                        {
                            // Delete all slides before index i
                            if (newIndex > 0)
                            {
                                DeleteSlide(filePath + i + ".pptx", 0);
                                countSlide--; // Decrease number of slides after you delete it
                                newIndex--;
                            }
                            // Delete all slides after index i
                            else if (newIndex < 0)
                            {
                                DeleteSlide(filePath + i + ".pptx", 1);
                                countSlide--; // Decrease number of slides after you delete it
                                newIndex--;
                            }
                            else newIndex--;
    
                        }
