    /// <summary>
    /// Stadium -> Sections -> Rows -> Seats
    /// </summary>
    public class Stadium : AggregateRoot
    {
        private readonly IDictionary<SectionCode, Section> _sections;
        public static Stadium Create(StadiumCode id, Section[] sections)
        {
            return new Stadium(id, sections);
        }
        public override string Id { get; }
        private Stadium(StadiumCode id, Section[] sections)
        {
            _sections = sections.ToDictionary(s => s.SectionId);
            Id = id.ToString();
        }
        public void BookASeat(SeatNumber seat, RowNumber row, SectionCode section, Person person)
        {
            if (!_sections.ContainsKey(section))
            {
                throw new InvalidOperationException($"There is no Section {section} on a stadium {Id}.");
            }
            _sections[section].BookASeat(row, seat, person);
        }
        public void AddASeat(Seat seat, RowNumber rowNumber, SectionCode sectionCode)
        {
            _sections.TryGetValue(sectionCode, out var section);
            if (section != null)
            {
                section.AddASeat(rowNumber, seat);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
        public void AddARow(Row row, SectionCode sectionCode)
        {
            _sections.TryGetValue(sectionCode, out var section);
            if (section != null)
            {
                section.AddARow(row);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
        public void AddASection(Section section)
        {
            if (_sections.ContainsKey(section.SectionId))
            {
                throw new InvalidOperationException();
            }
            _sections.Add(section.SectionId, section);
        }
    }
    public abstract class AggregateRoot
    {
        public abstract string Id { get; }
    }
    public class Entity { }
    public class ValueObject { }
    public class SeatNumber : ValueObject { }
    public class RowNumber : ValueObject { }
    public class SectionCode : ValueObject { }
    public class Person : ValueObject { }
    public class StadiumCode : ValueObject { }
    public class Row : Entity
    {
        private readonly IDictionary<SeatNumber, Seat> _seats;
        public Row(RowNumber rowId, Seat[] seats)
        {
            RowId = rowId;
            _seats = seats.ToDictionary(s => s.SeatId);
        }
        public RowNumber RowId { get; }
        public void BookASeat(SeatNumber seatId, Person person)
        {
            if (!_seats.ContainsKey(seatId))
            {
                throw new InvalidOperationException($"There is no Seat {seatId} in row {RowId}.");
            }
            _seats[seatId].Book(person);
        }
        public bool IsBooked(SeatNumber seatId) { throw new NotImplementedException(); }
        public void AddASeat(Seat seat)
        {
            if (_seats.ContainsKey(seat.SeatId))
            {
                throw new InvalidOperationException();
            }
            _seats.Add(seat.SeatId, seat);
        }
    }
    public class Section : Entity
    {
        private readonly IDictionary<RowNumber, Row> _rows;
        public Section(SectionCode sectionId, Row[] rows)
        {
            SectionId = sectionId;
            _rows = rows.ToDictionary(r => r.RowId);
        }
        public SectionCode SectionId { get; }
        public void BookASeat(RowNumber rowId, SeatNumber seatId, Person person)
        {
            if (!_rows.ContainsKey(rowId))
            {
                throw new InvalidOperationException($"There is no Row {rowId} in section {SectionId}.");
            }
            _rows[rowId].BookASeat(seatId, person);
        }
        public void AddASeat(RowNumber rowId, Seat seat)
        {
            _rows.TryGetValue(rowId, out var row);
            if (row != null)
            {
                row.AddASeat(seat);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
        public void AddARow(Row row)
        {
            if (_rows.ContainsKey(row.RowId))
            {
                throw new InvalidOperationException();
            }
            _rows.Add(row.RowId, row);
        }
    } 
