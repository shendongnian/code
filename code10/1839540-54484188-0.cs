    {
            //reads the double from position 8
            using (var mmf = MemoryMappedFile.OpenExisting("memory"))
            {
                using (var accessor = mmf.CreateViewAccessor())
                {
                    accessor.Read(1, out float omegay);
                    float omegayy = Convert.ToSingle(omegay);
                    transform.Rotate(new Vector3(0, omegayy, 0) * Time.deltaTime);
                }
            }
    }
