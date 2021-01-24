    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<WorkingInterestGroups> workingInterestGroups = new List<WorkingInterestGroups>();
                List<UnitTracts> unitTracts = new List<UnitTracts>();
                List<Tracts> tracts = new List<Tracts>();
                List<Leases> leases = new List<Leases>();
                List<AdditionalLeaseInfo> additionalLeaseInfos = new List<AdditionalLeaseInfo>();
                List<Interests> interests = new List<Interests>();
                var results = (from unitTract in unitTracts
                    join  tract in tracts on unitTract.TractId equals tract.Id 
                    join interest in interests on tract.Id equals interest.TractId
                    join workingInterestGroup in workingInterestGroups on interest.WorkingInterestGroupId equals workingInterestGroup.Id
                    join lease in leases on workingInterestGroup.LeaseId equals lease.Id
                    join additionalLeaseInfo in additionalLeaseInfos on lease.Id equals additionalLeaseInfo.LeaseId
                    where unitTract.UnitId == "21"
                    select new { unitTract = unitTract, tract = tract, interest = interest,  workingInterestGroup = workingInterestGroup,
                        lease = lease, additionalLeaseInfo = additionalLeaseInfo}).ToList();
                var groups = results.GroupBy(x => new
                {
                    x.unitTract.Id,
                    x.unitTract.UnitId,
                    x.lease.Lessor,
                    x.lease.Lessee,
                    x.lease.Alias,
                    x.lease.LeaseDate,
                    x.lease.GrossAcres,
                    x.lease.Legal,
                    x.interest.TractId,
                    x.lease.NetAcres,
                    x.unitTract.AcInUnit
                })
                    .ToList();
            }
        }
        public class WorkingInterestGroups
        {
            public string Id { get; set; }
            public string LeaseId { get; set; }
        }
        public class UnitTracts
        {
            public string TractId { get; set; }
            public string Id { get; set; }
            public string UnitId { get; set; }
            public string AcInUnit { get;set;}
        }
        public class Tracts
        {
            public string Id { get; set; }
        }
        public class Leases
        {
            public string Id { get; set; }
            public string Lessor { get; set; }
            public string Lessee { get; set; }
            public string Alias { get; set; }
            public string LeaseDate { get; set; }
            public string GrossAcres { get; set; }
            public string Legal { get; set; }
            public string NetAcres { get; set; }
        }
     
        public class AdditionalLeaseInfo
        {
            public string LeaseId { get; set;}
        }
        public class Interests
        {
            public string TractId { get; set; }
            public string WorkingInterestGroupId { get; set; }
        }
    }
