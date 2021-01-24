            var batches = new List<Batch>
            {
                new Batch
                {
                    Name = "Batch 1",
                    Duration = 100,
                    Fee = 200,
                    Students = new List<Student>
                    {
                        new Student
                        {
                            Name = "Student 1",
                            DateOfBirth = DateTime.Today,
                            RollNumber = 1
                        },
                        new Student
                        {
                            Name = "Student 2",
                            DateOfBirth = DateTime.Today,
                            RollNumber = 2
                        }
                    }
                }
            };
