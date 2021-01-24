               [Test]
                public void Set8NewImagesAndTotalGainsRemove2ImagesTest()
                {
                    _imageSelectionStory.WithScenario("init new ImagesSelectionViewModel and load 8 new images from database and assign total gain" +
                                                      " 1,2 to all, and then remove 2 images")
                        .Given(InitImageSelectionViewModelAndDatabaseImages)
                        .When(SetNewImagesFromDatabase)
                        .And(UpdateAssignedToTotalGainsAndRemove2Images)
                        .Then(ImageSelectionDatabaseIsValidImagesAllTotalGainsAssigned,6)
                        .Execute();
                }
                private void ImageSelectionDatabaseIsValidImagesAllTotalGainsAssigned(int expected)
                {
                   foreach (var image in _imagesSelectionViewModel.Images)
                  {
                       CollectionAssert.AreEqual(new List<double> { 1, 2 }, image.AssignedToTotalGain);
                  }
                  Assert.AreEqual(expected, _imagesSelectionViewModel.Images.Count);
                  Assert.True(_imagesSelectionViewModel.IsValid());
                }
