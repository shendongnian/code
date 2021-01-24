    public class MemberViewModel
    {
        private Member member;
        public MemberViewModel(Member member) => this.member = member;
        public int Id => member.id;
        public string Name => member.name;
        public double Salary => member.salary;
        public double? Bonus => member is Player player ? player.bonus : default(double?);
    }
