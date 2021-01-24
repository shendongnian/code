    public class MyGraphExtensionTest : PXGraphExtension<WCMaint>
    {
        public override void Initialize()
        {
            base.Initialize();
    
            PXUIFieldAttribute.SetVisible<AMShift.crewSize>(Base.WCShifts.Cache, null, false);
            PXUIFieldAttribute.SetVisible<AMShift.machNbr>(Base.WCShifts.Cache, null, false);
            PXUIFieldAttribute.SetVisible<AMShift.shftEff>(Base.WCShifts.Cache, null, false);
        }
    
        protected virtual void AMWC_RowInserted(PXCache sender, PXRowInsertedEventArgs e, PXRowInserted del)
        {
            if (del != null)
            {
                del(sender, e);
            }
    
            var row = (AMWC) e.Row;
            if (string.IsNullOrWhiteSpace(row?.WcID) || Base.IsImport || Base.IsContractBasedAPI || Base.WCShifts.Cache.Inserted.Any_())
            {
                return;
            }
    
            Base.WCShifts.Insert(new AMShift
            {
                WcID = row.WcID
            });
        }
    
        protected virtual void AMShift_ShiftID_FieldDefaulting(PXCache sender, PXFieldDefaultingEventArgs e, PXFieldDefaulting del)
        {
            if (del != null)
            {
                del(sender, e);
            }
    
            AMShift doc = e.Row as AMShift;
    
            if (doc != null)
            {
                AMShiftMst AMShiftMstData = PXSelect<AMShiftMst, Where<AMShiftMst.shiftID, Equal<Required<AMShiftMst.shiftID>>>>.Select(Base, "1");
    
                if (AMShiftMstData != null)
                {
                    e.NewValue = AMShiftMstData.ShiftID;
                }
            }
        }
    
        protected virtual void AMShift_CalendarID_FieldDefaulting(PXCache sender, PXFieldDefaultingEventArgs e, PXFieldDefaulting del)
        {
            if (del != null)
            {
                del(sender, e);
            }
    
            AMShift doc = e.Row as AMShift;
    
            if (doc != null)
            {
                CSCalendar CSCalendarData = PXSelect<CSCalendar, Where<CSCalendar.calendarID, Equal<Required<CSCalendar.calendarID>>>>.Select(Base, "OFFICE");
    
                if (CSCalendarData != null)
                {
                    e.NewValue = CSCalendarData.CalendarID;
                }
            }
        }
        protected virtual void AMShift_LaborCodeID_FieldDefaulting(PXCache sender, PXFieldDefaultingEventArgs e, PXFieldDefaulting del)
        {
            if (del != null)
            {
                del(sender, e);
            }
    
            AMShift doc = e.Row as AMShift;
    
            if (doc != null)
            {
                AMLaborCode AMLaborCodeData = PXSelect<AMLaborCode, Where<AMLaborCode.laborCodeID, Equal<Required<AMLaborCode.laborCodeID>>>>.Select(Base, "DIRECT");
    
                if (AMLaborCodeData != null)
                {
                    e.NewValue = AMLaborCodeData.LaborCodeID;
                }
            }
        }
    }
