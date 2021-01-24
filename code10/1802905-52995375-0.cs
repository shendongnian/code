    context.CalibrationTargets.AddOrUpdate(
        x => x.CalibrationTargetId,  // This is the field that determines uniqueness 
        new CalibrationTarget
        {
            CalibrationTargetId = 1,  // if this is an identity column, omit and use a different field above for uniqueness
            TargetIndex = 99,  // what value for target index? Fixed value or variable can be used
            CalibrationSetup = new CalibrationSetup { Id = 77 }  // Same as above comment
        },
        new CalibrationTarget
        {
            CalibrationTargetId = 2,  // if this is an identity column, omit and use a different field above for uniqueness
            TargetIndex = 88,  // what value for target index? Fixed value or variable can be used
            CalibrationSetup = new CalibrationSetup { Id = 66 }  // Same as above comment
        }
        ... repeat for all seeded records
        );
    context.SaveChanges();
