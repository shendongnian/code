        List<TVSystemViewData> model;
        
        [Display(Name = "AccountId", Description = "")]
        public String AccountId { get; set; }
        [Display(Name = "AllocatedManagedMemory", Description = "")]
        public String AllocatedManagedMemory { get; set; }
        [Display(Name = "AllocatedPhysicalMemory", Description = "")]
        public String AllocatedPhysicalMemory { get; set; }
        [Display(Name = "AudioMute", Description = "")]
        public String AudioMute { get; set; }
        public IEnumerator<TVSystemViewData> GetEnumerator()
        {
            foreach (var item in model)
            {
                yield return item;
            }
        }
