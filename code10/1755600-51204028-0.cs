     public class FamilyMember: ICloneable
    {
        public string Name { get; set; }
        ...
        public virtual object Clone()
        {
            return (FamilyMember) this.MemberwiseClone();
        }
    }
    private void BtnCopy_Click(object sender, EventArgs e)
    {
        List<Familymember> selectedFamilyMemberList = ((BindingList<Familymember>)dgvFamilyMember.DataSource).ToList();
        if (selectedFamilyMemberList != null && selectedFamilyMemberList .Count > 0)
        {
            foreach (FamilyMember item in selectedFamilyMemberList)
            {
                CopiedFamilyMemberList.Add((FamilyMember)item.Clone());
            }
            btnPaste.Enabled = true;
        }
    }
