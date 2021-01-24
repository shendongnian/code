    static Student.FeeCollection ToStudentFeeCollection(this IEnumerable<Fee> fees)
    {
          Student.FeeCollection feeCollection = new Student.FeeCollection();
          foreach (Fee fee in fees)
          {
              feeCollection.Add(fee);
          }
          return feeCollection;
    }
    static Student.FeeCollection ToStudentFeeCollection(this SchoolFee.Collection schoolFeeCollection)
    {
         IEnumerable<Fee> schoolFees = schoolFeeCollection;
         return schoolFees.ToStudentFees();
         // or if you don't want to implement IEnumerable<Fee>:
         var studentFeeCollection = new Student.FeeCollection();
         foreach (var schoolFee in schoolFeeCollection.GetFees())
         {
              studentFeeCollection.Add(schoolFee);
         }
    }
