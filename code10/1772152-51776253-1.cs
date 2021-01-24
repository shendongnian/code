    RuntimeTypeModel.DynamicTypeFormatting += (sender, args) => {
        if (args.FormattedName != null) { // meaning: rehydrating
            lock(SomeSyncLock) {
                if(NotYetKnown(args.FormattedName))
                    Prepare(args.FormattedName);
            }
        }
    };
